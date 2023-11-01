import {defaultDatagridConfig} from "../../../../config/dxDefault/dxDatagrid.default.ts";
import {Button, Column, DataGrid, Item, Lookup} from "devextreme-react/data-grid";
import {stripHTML} from "../../../../utils/html.util.ts";
import {useDataSource} from "../../../../core/hooks/useDatasources.ts";
import {useTranslation} from "react-i18next";
import {forwardRef, RefObject, useImperativeHandle, useRef} from "react";
import {Form, Popup, Tooltip} from "devextreme-react";
import {useGetUsersByProject} from "../../../../core/hooks/useGetUsers.ts";
import {useParams} from "react-router-dom";
import {datagridStore} from "../../../../core/datagridStore.ts";
import {url} from "../../../../utils/urlConstructor.ts";


type  TicketListProps = {
	popUpRef: RefObject<Popup>
	formRef: RefObject<Form>
	loadTicket:any
}
export type TicketListRef = {
	update: () => void
}
export const TicketList = forwardRef<TicketListRef, TicketListProps>(({popUpRef, formRef,loadTicket}: TicketListProps, ref) => {


	const dataSource = useDataSource(["TicketCategory", "TicketStatus", "TicketPriority"] as const)
	const {t} = useTranslation()
	const {id} = useParams<{ id: string }>()
	const {users} = useGetUsersByProject(id!)
	const dgRef = useRef<DataGrid>(null)
	useImperativeHandle(ref, () => ({
		update() {
			dgRef.current?.instance.refresh();
		}
	}));

	return (
		<div>
			<DataGrid
				ref={dgRef}
				dataSource={datagridStore({
					key: "Id",
					loadUrl: url({
						controller: "Ticket",
						action: "getAllByProject",
						parameter: id
					})
				})}
				{...defaultDatagridConfig}

			>

				<Item name="groupPanel" location="before"/>
				<Item name="searchPanel" location="after"/>
				<Item name="columnChooserButton" location="after"/>
				<Item name="addRowButton" location="after"/>
				<Item name="exportButton" location="after"/>

				<Column dataField={"ResponsibleUserId"} width={100} caption={t("table.ticketList.caption.ResponsibleUserId")}
						cellRender={(data) => {
							const target = `ticket_${data.row.data.Id}`;
							return data.text ? <>
								<div className={"user-banner bg-yellow-600 text-[12px] w-7 h-7"} id={target}>
									{data.text.split(" ")[0][0] + data.text.split(" ")[1][0]}
								</div>
								<Tooltip target={"div#" + target} showEvent={"mouseenter"} hideEvent={"mouseleave"}>
									<div>
										{data.text}
									</div>
								</Tooltip>
							</> : null
						}}>
					<Lookup dataSource={users} valueExpr={"Id"} displayExpr={"FullName"}/>
				</Column>
				<Column dataField={"Title"} caption={t("table.ticketList.caption.Title")}/>
				<Column dataField={"Description"} cellRender={(data) => <div>{stripHTML(data.value || "")}</div>}
						caption={t("table.ticketList.caption.Description")}/>
				<Column dataField={"CategoryId"} caption={t("table.ticketList.caption.CategoryId")}>
					<Lookup dataSource={dataSource.TicketCategory} valueExpr={"Id"} displayExpr={"NameL1"}/>
				</Column>
				<Column dataField={"StatusId"} caption={t("table.ticketList.caption.StatusId")}>
					<Lookup dataSource={dataSource.TicketStatus} valueExpr={"Id"} displayExpr={"NameL1"}/>

				</Column>
				<Column dataField={"DeadLine"} caption={t("table.ticketList.caption.DeadLine")} dataType={"datetime"}
					defaultSortIndex={0} defaultSortOrder={"asc"}>


				</Column>

				<Column dataField={"PriorityId"} caption={t("table.ticketList.caption.PriorityId")}>
					<Lookup dataSource={dataSource.TicketPriority} valueExpr={"Id"} displayExpr={"NameL1"}/>
				</Column>

				<Column type={"buttons"}>
					<Button icon={"eyeopen"} onClick={(data) => {
						loadTicket(data.row.key).then((data: any) => {
							formRef.current?.instance.option("formData", data);

						})
						formRef.current?.instance.option("isEditing", true);
						popUpRef.current?.instance.show();

					}}/>
				</Column>
			</DataGrid>
		</div>

	)
})