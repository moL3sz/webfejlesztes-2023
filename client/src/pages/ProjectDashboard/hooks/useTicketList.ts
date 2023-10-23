import {useParams} from "react-router-dom";
import {useCallback, useEffect, useState} from "react";
import {getApi} from "../../../config/api/api.ts";
import {url} from "../../../utils/urlConstructor.ts";


export const useTicketList = ()=>{
	const {id} = useParams<{id:string}>()


	const [tickets, setTickets] = useState<any[]>([])

	const fetchTickets = useCallback(async ()=>{
		const response= await getApi().get(url({
			controller: "Ticket",
			action: "getAllByProject",
			parameter: id
		}));
		setTickets(response.data);
	},[id])



	useEffect(()=>{
		fetchTickets();
	},[])
	return {tickets, fetchTickets};
}