import {Ticket} from "./@types/statusTasks.type.ts";

export type KanbanCardProps = {
	ticket: Ticket
}

export const KanbanCard = ({ticket}: KanbanCardProps) => {
	return (
		<div className={"min-h-[10em] border-[1px] bg-zinc-700 my-2 p-2 rounded-md"}>
			<div className={"text-left text-lg"}>{ticket.Title}</div>
			<div className={"desc"}>
				{ticket.Description}
			</div>
		</div>
	)
}