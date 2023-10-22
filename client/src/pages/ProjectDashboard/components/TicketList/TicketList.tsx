import {defaultDatagridConfig} from "../../../../config/dxDefault/dxDatagrid.default.ts";
import {Button, Column, DataGrid, Item} from "devextreme-react/data-grid";
import {useTicketList} from "../../hooks/useTicketList.ts";

export const TicketList = () => {


	const {tickets} = useTicketList();


	return (
		<div className={"dashboard-card"}>
			<h5>Feladatok</h5>
			<DataGrid
				dataSource={tickets}
				keyExpr={"Id"}
				{...defaultDatagridConfig}
			>
				<Item name="groupPanel" location="before"/>
				<Item name="searchPanel" location="after"/>
				<Item name="columnChooserButton" location="after"/>
				<Item name="addRowButton" location="after"/>
				<Item name="exportButton" location="after"/>

				<Column dataField={"Title"}/>
				<Column dataField={"Description"}/>
				<Column dataField={"CategoryId"}/>
				<Column dataField={"StatusId"}/>
				<Column dataField={"PriorityId"}/>
				<Column type={"buttons"}>
					<Button icon={"eyeopen"} onClick={()=>{}}/>
				</Column>
			</DataGrid>
		</div>

	)
}