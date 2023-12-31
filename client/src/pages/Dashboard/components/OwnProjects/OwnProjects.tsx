import {useOwnProjects} from "./hooks/useOwnProjects.ts";
import {Column, DataGrid, Item, Button} from "devextreme-react/data-grid";
import {defaultDatagridConfig} from "../../../../config/dxDefault/dxDatagrid.default.ts";
import {stripHTML} from "../../../../utils/html.util.ts";


export const OwnProjects = () => {
	const {projects,navigateToProject} = useOwnProjects()
	return (
		<div>
			<DataGrid
				dataSource={projects}
				keyExpr={"Id"}
				{...defaultDatagridConfig}
				height={600}
			>
				<Item name="groupPanel" location="before"/>
				<Item name="searchPanel" location="after"/>
				<Item name="columnChooserButton" location="after"/>
				<Item name="addRowButton" location="after"/>
				<Item name="exportButton" location="after"/>

				<Column dataField={"Title"}/>
				<Column dataField={"Description"} cellRender={(data)=><div>{stripHTML(data.value || "")}</div>}/>
				<Column dataField={"Code"}/>
				<Column dataField={"Start"} dataType={"date"}/>
				<Column dataField={"End"} dataType={"date"}/>
				<Column type={"buttons"}>
					<Button icon={"eyeopen"} onClick={navigateToProject}/>
				</Column>
			</DataGrid>
		</div>
	)
}