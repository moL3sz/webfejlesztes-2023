import {useParams} from "react-router-dom";
import {useCallback, useEffect, useRef, useState} from "react";
import {ProjectFullDTOType} from "../../../@types/project.type.ts";
import {getApi} from "../../../config/api/api.ts";
import {url} from "../../../utils/urlConstructor.ts";
import {Actions} from "../../../config/api/actions.enum.ts";
import {Form, Popup, TagBox} from "devextreme-react";
import {useTranslation} from "react-i18next";
import {useDataSource} from "../../../core/hooks/useDatasources.ts";
import {useGetUsersByProject} from "../../../core/hooks/useGetUsers.ts";
import {useAppDispatch} from "../../../store/hooks.ts";
import {setCurrentProjectId} from "../../../store/currentProject/drawer.slice.ts";
import {defaultNotify} from "../../../config/dxDefault/toast.default.ts";
import {TicketListRef} from "../components/TicketList/TicketList.tsx";
import {useIsAdminInProject} from "../../../core/hooks/useIsAdminInProject.ts";


export const useProjectDashboard = () => {

	const {id} = useParams<{ id: string }>();
	const [project, setProject] = useState<ProjectFullDTOType>();
	const {t} = useTranslation();
	const {users} = useGetUsersByProject(id!)
	const dispatch = useAppDispatch()
	const isAdminInProject = useIsAdminInProject();

	const addTicketPopupRef = useRef<Popup>(null)
	const ticketFormRef = useRef<Form>(null)

	const inviteMemberPopupRef = useRef<Popup>(null)
	const memberListTagBoxRef = useRef<TagBox>(null)
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
		const message = isEditing ? "Sikeresen módosítottad a feladatot" : "Sikeresen létrehoztad a feladatot"
		defaultNotify(message, "success")
		addTicketPopupRef.current?.instance.hide()
		ticketListRef.current?.update();

	}, [id])

	const invitePeople = useCallback(async ()=>{
		const data = memberListTagBoxRef.current?.instance.option("value");
		try {
			await getApi().put(url({
				controller: "ProjectUser",
				action:"invitePeople",
				parameter: id
			}), {
				Emails: data
			})
			defaultNotify("Sikeresen meghívtad az adott felhasználókat!", "info")
			inviteMemberPopupRef.current?.instance.hide();
		}catch (e){
			defaultNotify("Nem sikerült meghívni a felhasználókat!", "error")
		}
	},[])

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
		inviteMemberPopupRef,
		memberListTagBoxRef,
		invitePeople,
		isAdminInProject
	}

}