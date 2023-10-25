import {useCallback, useEffect, useState} from "react";
import {getApi} from "../../../../../config/api/api.ts";
import {url} from "../../../../../utils/urlConstructor.ts";
import {useAppSelector} from "../../../../../store/hooks.ts";
import {Simulate} from "react-dom/test-utils";
import {StatusTasksType} from "../@types/statusTasks.type.ts";


export const useKanbanBoard = () => {


	const [statusTasks, setStatusTasks] = useState<StatusTasksType[]>([]);
	const projectId = useAppSelector(state => state.currentProject.currentProjectId)

	const fetchKanbanBoard = useCallback(async () => {
		if(!projectId) return;
		const response = await getApi().get(url({
			controller: "Project",
			action: "getKanbanBoard",
			parameter: projectId!.toString()
		}));

		console.log(response);

		setStatusTasks(response.data)
	}, [projectId])


	useEffect(() => {
		fetchKanbanBoard();
	}, [fetchKanbanBoard])


	return {
		statusTasks
	}
}