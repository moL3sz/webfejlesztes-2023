import {useCallback, useEffect, useState} from "react";
import {getApi} from "../../config/api/api.ts";
import {url} from "../../utils/urlConstructor.ts";


export const useGetUsersByProject = (projectId: string)=>{

	const [users, setUsers] = useState<any[]>([])

	const fetchUsers = useCallback(async ()=>{
		const response = await getApi().get(url({
			controller: "ProjectUser",
			action:"getUsersByProject",
			parameter:projectId
		}))
		setUsers(response.data)
	},[])

	useEffect(()=>{
		fetchUsers()
	},[])
	return {users}
}