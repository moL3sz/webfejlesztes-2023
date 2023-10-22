import {useParams} from "react-router-dom";
import {useCallback, useEffect, useRef, useState} from "react";
import {ProjectFullDTOType} from "../../../@types/project.type.ts";
import {getApi} from "../../../config/api/api.ts";
import {url} from "../../../utils/urlConstructor.ts";
import {Actions} from "../../../config/api/actions.enum.ts";
import {Form, Popup} from "devextreme-react";
import {useTranslation} from "react-i18next";


export const useProjectDashboard = ()=>{

	const {id} = useParams<{id:string}>();
	const [project, setProject] = useState<ProjectFullDTOType>();
	const {t} = useTranslation();

	const addTicketPopupRef = useRef<Popup>(null)
	const ticketFormRef = useRef<Form>(null)


	const loadProject = useCallback(async ()=>{
		const response = await getApi().get<ProjectFullDTOType>(url({
			controller: "Project",
			action:Actions.GET_BY_ID,
			parameter: id
		}))
		setProject(response.data)
	},[id])

	useEffect(()=>{
		loadProject()
	},[loadProject])


	return {project, addTicketPopupRef,ticketFormRef,t}

}