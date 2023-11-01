import {ScrollView} from "devextreme-react";
import {useKanbanBoard} from "./hooks/useKanbanBoard.ts";
import {KanbanStatusList} from "./KanbanStatusList.tsx";


export const KanbanBoard = ()=>{

	const {statusTasks,onTaskDrop} = useKanbanBoard();
	return (

		<div id={"kanban"}>
			<ScrollView
				className="scrollable-board"
				direction="horizontal"
				showScrollbar="always">
				<div
					className="sortable-lists"
					>
					{statusTasks.map((statusItem) => {
						const status = statusItem.Status;
						return <KanbanStatusList
							key={status.Id}
							title={status.NameL1}
							onTaskDrop={onTaskDrop}
							index={status.Id}
							tickets={statusItem.Tickets}
					/>;
					})}
				</div>
			</ScrollView>
		</div>
	)
}