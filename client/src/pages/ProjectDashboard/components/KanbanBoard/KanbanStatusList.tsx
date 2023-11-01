import {Ticket} from "./@types/statusTasks.type.ts";
import {ScrollView, Sortable} from "devextreme-react";
import {KanbanCard} from "./KanbanCard.tsx";


export type KanbanStatusListProps = {
	tickets: Ticket[],
	title: string,
	onTaskDrop: any,
	index: number,

}
export const KanbanStatusList = ({tickets, title, onTaskDrop, index}: KanbanStatusListProps) => {


	return (

		<div className="list p-5">
			<div className="list-title dx-theme-text-color">{title}</div>
			<ScrollView
				className="scrollable-list"
				direction="vertical"
				showScrollbar={"onScroll"}>
				<Sortable
					className="sortable-cards"
					group="cardsGroup"

					data={index}
					onReorder={onTaskDrop}
					onAdd={onTaskDrop}>
					{tickets.map((ticket) => <KanbanCard
						key={ticket.Id}
						ticket={ticket}/>
					)}
				</Sortable>
			</ScrollView>
		</div>

	)
}