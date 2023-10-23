import {useUser} from "../../../../../core/hooks/useUser.ts";
import {useCallback, useEffect, useState} from "react";
import {getApi} from "../../../../../config/api/api.ts";
import {url} from "../../../../../utils/urlConstructor.ts";
import {useNavigate} from "react-router-dom";


export  const useOwnProjects = ()=>{
	const {user} = useUser();
	const [projects,setProjects] = useState<any[]>([])
	const navigate = useNavigate();

	const getOwnProjects = useCallback(async ()=>{
		if(!user) return;
		const response = await getApi().get(url({
			controller: "ProjectUser",
			action: "getProjectsByUser",
			parameter: user.nameid
		}))
		setProjects(response.data)
	},[user])

	const navigateToProject = (event:any)=>{
		const Id = event.row.key;
		navigate("/project/"+Id);
	}
	useEffect(()=>{
		getOwnProjects();
	},[user])

	return {
		projects,
		navigateToProject
	}
}