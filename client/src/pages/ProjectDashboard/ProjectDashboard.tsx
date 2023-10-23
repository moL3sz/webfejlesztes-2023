import {Item as ToolbarItem, Toolbar} from "devextreme-react/toolbar";
import {useProjectDashboard} from "./hooks/useProjectDashboard.ts";
import {TicketList} from "./components/TicketList/TicketList.tsx";
import {Form, Popup} from "devextreme-react";
import {ToolbarItem as PopupToolbarItem} from "devextreme-react/popup"
import {GroupItem, Label, RequiredRule, SimpleItem} from "devextreme-react/form";
import {DxHtmlEditorDefault} from "../../config/dxDefault/dxHtmlEditor.default.ts";
import {DashboardCard} from "../Dashboard/components/DashboardCard/DashboardCard.tsx";
import {BurnDownChart} from "./components/BurnDownChart.tsx";


export const ProjectDashboard = () => {

	const {
		project,
		addTicketPopupRef,
		ticketFormRef,
		t,
		saveTicket,
		dataSource,
		users,
		ticketListRef,
		loadTicketById,
	} = useProjectDashboard()

	return (
		<div className={"h-[100vh]"}>
			<Toolbar className={"border-b-[1px] border-b-zinc-600 mb-4"}>
				<ToolbarItem location={"before"} render={() => (
					<h5>{project?.Title}</h5>
				)}/>
				<ToolbarItem widget={"dxButton"} location={"after"} options={{
					text: "Emberek meghívása", //TODO: Resouce
					type: "normal",
					stylingMode: "filled",
					icon: "message"
				}}/>
				<ToolbarItem widget={"dxButton"} location={"after"} options={{
					text: "Feladat",//TODO: Resouce
					stylingMode: "filled",
					icon: "plus",
					type: "default",
					onClick: () => {
						ticketFormRef.current?.instance.resetValues();
						addTicketPopupRef.current?.instance.show();
					}
				}}/>
			</Toolbar>
			<div className={"project-container grid md:grid-cols-1 lg:grid-cols-2 grid-cols-1 gap-5"}>
				<DashboardCard colSpan={"full"}>
					<TicketList ref={ticketListRef} formRef={ticketFormRef} loadTicket={loadTicketById}
								popUpRef={addTicketPopupRef}/>
				</DashboardCard>
				<DashboardCard>
				<BurnDownChart/>
				</DashboardCard>
				<DashboardCard/>
				<DashboardCard/>
			</div>

			{/* Add ticket */}
			<Popup width={"50%"}
				   hideOnOutsideClick={true}
				   title={t("popup.title.addTicket")}
				   ref={addTicketPopupRef}
				   onHiding={(e) => {
					   ticketFormRef.current?.instance.resetOption("isEditing");
					   e.component.hide();
				   }}
			>
				<Form ref={ticketFormRef}>
					<SimpleItem dataField={"Title"}>
						<Label text={t("label.ticket.Title")}/>
						<RequiredRule/>
					</SimpleItem>
					<GroupItem colCount={2}>
						<SimpleItem dataField={"CategoryId"} editorType={"dxSelectBox"} editorOptions={{
							dataSource: dataSource.TicketCategory,
							displayExpr: "NameL1",
							valueExpr: "Id"
						}}>
							<Label text={t("label.ticket.CategoryId")}/>
							<RequiredRule/>
						</SimpleItem>
						<SimpleItem dataField={"StatusId"} editorType={"dxSelectBox"} editorOptions={{
							dataSource: dataSource.TicketStatus,
							displayExpr: "NameL1",
							valueExpr: "Id"
						}}>
							<Label text={t("label.ticket.StatusId")}/>
							<RequiredRule/>
						</SimpleItem>
						<SimpleItem dataField={"PriorityId"} editorType={"dxSelectBox"} editorOptions={{
							dataSource: dataSource.TicketPriority,
							displayExpr: "NameL1",
							valueExpr: "Id"
						}}>
							<RequiredRule/>
							<Label text={t("label.ticket.PriorityId")}/>
						</SimpleItem>
						<SimpleItem dataField={"ResponsibleUserId"} editorType={"dxSelectBox"} editorOptions={{
							dataSource: users,
							displayExpr: "FullName",
							valueExpr: "Id"
						}}>
							<RequiredRule/>
							<Label text={t("label.ticket.ResponsibleUserId")}/>
						</SimpleItem>
						<SimpleItem dataField={"DeadLine"} editorType={"dxDateBox"}>
							<RequiredRule/>
							<Label text={t("label.ticket.DeadLine")}/>
						</SimpleItem>
					</GroupItem>
					<SimpleItem dataField={"Description"} editorType={"dxHtmlEditor"} editorOptions={{
						height: 200,
						...DxHtmlEditorDefault
					}}>
						<Label text={t("label.ticket.Description")}/>
					</SimpleItem>

				</Form>
				<PopupToolbarItem toolbar={"bottom"} widget={"dxButton"} location={"after"} options={{
					icon: "save",
					text: "Mentés",
					type: "success",
					stylingMode: "filled",
					onClick: saveTicket
				}}/>
				<PopupToolbarItem toolbar={"bottom"} widget={"dxButton"} location={"after"} options={{
					icon: "remove",
					text: "Mégse",
					type: "danger",
					stylingMode: "outlined",
					onClick: () => addTicketPopupRef.current?.instance.hide()
				}}/>
			</Popup>
		</div>
	)

}