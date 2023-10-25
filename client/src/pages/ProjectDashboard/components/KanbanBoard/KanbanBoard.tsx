import {ScrollView, Sortable} from "devextreme-react";
import {useKanbanBoard} from "./hooks/useKanbanBoard.ts";
import {KanbanStatusList} from "./KanbanStatusList.tsx";


export const KanbanBoard = ()=>{

	const {statusTasks} = useKanbanBoard();
	return (

		<div id={"kanban"}>
			<ScrollView
				className="scrollable-board"
				direction="horizontal"
				showScrollbar="always">
				<Sortable
					className="sortable-lists"
					itemOrientation="horizontal"
					handle=".list-title">
					{statusTasks.map((statusItem, listIndex) => {
						const status = statusItem.Status;
						return <KanbanStatusList
							key={status.Id}
							title={status.NameL1}
							onTaskDrop={null}
							index={listIndex}
							tickets={statusItem.Tickets}
					/>;
					})}
				</Sortable>
			</ScrollView>
		</div>
	)
}