import {Ticket} from "./@types/statusTasks.type.ts";
import {stripHTML} from "../../../../utils/html.util.ts";
import {memo, useCallback, useEffect, useState} from "react";
import {getApi} from "../../../../config/api/api.ts";
import {url} from "../../../../utils/urlConstructor.ts";
import {Actions} from "../../../../config/api/actions.enum.ts";

export type KanbanCardProps = {
	ticket: Ticket
}

export const KanbanCard = memo(({ticket}: KanbanCardProps) => {
	const [user, setUser] = useState<any>()
	const fetchUser = useCallback(async () => {

		const response = await getApi().get(url({
			controller: "User",
			action: Actions.GET_BY_ID,
			parameter: ticket.ResponsibleUserId
		}))
		setUser(response.data)


	}, [])
	useEffect(() => {
		fetchUser();
	}, [])
	return (
		<div className={"min-h-[10em] h-auto bg-zinc-800 my-2 p-2 rounded-md flex flex-col"}>
			<div className={"flex justify-between px-2 mb-2"}>
				<div className={"text-left text-lg"}>{ticket.Title}</div>
				<div className={"user-banner bg-red-400 scale-90"}>{user?.LastName[0] + user?.FirstName[0]}</div>
			</div>
			<div className={"flex flex-col justify-between h-full flex-grow-[1]"}>
				<div className={"desc text-xs"}>
					{
						(ticket.Description || "").length > 90 ? (stripHTML(ticket.Description || "").substring(0, 90) + "...") : stripHTML(ticket.Description || "")
					}
				</div>
				<div className={"flex justify-end text-xs"}>{new Date(ticket.DeadLine).toLocaleDateString()}</div>
			</div>


		</div>
	)
})