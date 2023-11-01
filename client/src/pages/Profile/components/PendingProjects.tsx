import {Button, Column, DataGrid, Item} from "devextreme-react/data-grid";
import {defaultDatagridConfig} from "../../../config/dxDefault/dxDatagrid.default.ts";
import {usePendingProjects} from "../hooks/usePendingProjects.ts";

export const PendingProjects = () => {
	const {pendingProjectStore,acceptProject,t,dgRef} = usePendingProjects()

	return (<div>
		<DataGrid
			ref={dgRef}
			dataSource={pendingProjectStore}
			keyExpr={"Id"}
			{...defaultDatagridConfig}
			height={600}
		>
			<Item name="groupPanel" location="before"/>
			<Item name="searchPanel" location="after"/>
			<Item name="columnChooserButton" location="after"/>
			<Item name="addRowButton" location="after"/>
			<Item name="exportButton" location="after"/>

			<Column dataField={"Title"} caption={t("table.project.caption.Title")}/>
			<Column dataField={"Code"} caption={t("table.project.caption.Code")}/>
			<Column dataField={"Accepted"} dataType={"boolean"} caption={t("table.project.caption.Accepted")}/>
			<Column type={"buttons"}>
				<Button icon={"check"} onClick={acceptProject} hint={"Elfogad"}/>
			</Column>
		</DataGrid>

	</div>)


}