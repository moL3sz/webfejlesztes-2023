import {useEffect, useState} from "react";
import {getApi} from "../../../../../config/api/api.ts";
import {url} from "../../../../../utils/urlConstructor.ts";
import {useParams} from "react-router-dom";


export const useMemberList = ()=>{



	const [members, setMembers] = useState<any[]>([])
	const {id} = useParams<{id:string}>()

	const fetchMembers = async ()=>{
		const response = await getApi().get(url({
			controller: "ProjectUser",
			action: "getUsersByProject",
			parameter: id
		}))
		console.log(response.data)
		setMembers(response.data);
	}

	useEffect(()=>{
		fetchMembers();
	},[])

	return {
		members
	}
}