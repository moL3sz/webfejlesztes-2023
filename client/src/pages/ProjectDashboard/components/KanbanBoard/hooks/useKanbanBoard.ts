import {useCallback, useEffect, useState} from "react";
import {getApi} from "../../../../../config/api/api.ts";
import {url} from "../../../../../utils/urlConstructor.ts";
import {useAppSelector} from "../../../../../store/hooks.ts";
import {StatusTasksType} from "../@types/statusTasks.type.ts";


export const useKanbanBoard = () => {


	const [statusTasks, setStatusTasks] = useState<StatusTasksType[]>([]);
	const projectId = useAppSelector(state => state.currentProject.currentProjectId)

	const fetchKanbanBoard = useCallback(async () => {
		if (!projectId) return;
		const response = await getApi().get(url({
			controller: "Project",
			action: "getKanbanBoard",
			parameter: projectId!.toString()
		}));


		setStatusTasks(response.data)
	}, [projectId])
	const onTaskDrop = (event: any) => {
		const {fromData, toData, fromIndex, toIndex} = event;
		const nextState = [...statusTasks]
		const currentTicket = nextState.filter(x => x.Status.Id === fromData)[0].Tickets[fromIndex];
		nextState.filter(x => x.Status.Id === fromData)[0].Tickets.splice(fromIndex, 1);
		nextState.filter(x => x.Status.Id === toData)[0].Tickets.splice(toIndex, 0, currentTicket);

		getApi().put(url({
			controller: "Ticket",
			action: "updateStatus",
		}), {statusId: toData, Id: currentTicket.Id})
		setStatusTasks(nextState)
	}


	useEffect(() => {
		fetchKanbanBoard();
	}, [fetchKanbanBoard])


	return {
		statusTasks, onTaskDrop
	}
}