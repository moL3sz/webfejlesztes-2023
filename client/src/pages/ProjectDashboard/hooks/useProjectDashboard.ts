import {useParams} from "react-router-dom";
import {useCallback, useEffect, useRef, useState} from "react";
import {ProjectFullDTOType} from "../../../@types/project.type.ts";
import {getApi} from "../../../config/api/api.ts";
import {url} from "../../../utils/urlConstructor.ts";
import {Actions} from "../../../config/api/actions.enum.ts";
import {Form, Popup} from "devextreme-react";
import {useTranslation} from "react-i18next";
import {useDataSource} from "../../../core/hooks/useDatasources.ts";
import {useGetUsersByProject} from "../../../core/hooks/useGetUsers.ts";
import {useAppDispatch} from "../../../store/hooks.ts";
import {setCurrentProjectId} from "../../../store/currentProject/drawer.slice.ts";
import {defaultNotify} from "../../../config/dxDefault/toast.default.ts";
import {TicketListRef} from "../components/TicketList/TicketList.tsx";


export const useProjectDashboard = () => {

	const {id} = useParams<{ id: string }>();
	const [project, setProject] = useState<ProjectFullDTOType>();
	const {t} = useTranslation();
	const {users} = useGetUsersByProject(id!)
	const dispatch = useAppDispatch()

	const addTicketPopupRef = useRef<Popup>(null)
	const ticketFormRef = useRef<Form>(null)
	const dataSource = useDataSource(["TicketCategory", "TicketStatus", "TicketPriority"] as const)
	const ticketListRef = useRef<TicketListRef>(null)

	const loadProject = useCallback(async () => {
		const response = await getApi().get<ProjectFullDTOType>(url({
			controller: "Project",
			action: Actions.GET_BY_ID,
			parameter: id
		}))
		setProject(response.data)
	}, [id])

	const loadTicketById = useCallback(async (ticketId: string | number) => {
		const response = await getApi().get(url({
			controller: "Ticket",
			action: Actions.GET_BY_ID,
			parameter: ticketId.toString()
		}))
		return response.data
	}, [])

	const saveTicket = useCallback(async () => {
		const validationStatus = ticketFormRef.current?.instance.validate();
		const isEditing = ticketFormRef.current?.instance.option("isEditing");
		console.log(isEditing)
		if (!validationStatus?.isValid) return;

		let formData = ticketFormRef.current?.instance.option("formData");
		formData = {...formData, ProjectId: id}
		await getApi()(url({
			controller: "Ticket",
			action: isEditing ? Actions.UPDATE : Actions.INSERT,
		}), {
			method: isEditing ? "PUT" : "POST",
			data: formData
		})

		defaultNotify("Sikeresen létrehoztad a feladatot", "success")
		addTicketPopupRef.current?.instance.hide()
		ticketListRef.current?.update();

	}, [id])


	useEffect(() => {
		loadProject()
		dispatch(setCurrentProjectId(id!))
		return () => {
			dispatch(setCurrentProjectId(null))
		}
	}, [])


	return {
		project,
		addTicketPopupRef,
		ticketFormRef,
		t,
		saveTicket,
		dataSource,
		users,
		ticketListRef,
		loadTicketById,
	}

}