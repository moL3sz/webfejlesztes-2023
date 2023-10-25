import {useCallback, useEffect, useRef, useState} from "react";
import {useParams} from "react-router-dom";
import {getApi} from "../../../config/api/api.ts";
import {url} from "../../../utils/urlConstructor.ts";
import {Actions} from "../../../config/api/actions.enum.ts";
import {Form} from "devextreme-react";


export  const useUserProfile = ()=>{

	const {userId} = useParams<{userId: string}>()
	const userProfileFormRef = useRef<Form>(null)

	const fetchUser = useCallback(async()=>{

		const response = await getApi().get(url({
			controller: "User",
			action: Actions.GET_BY_ID,
			parameter: userId
		}))

		userProfileFormRef.current?.instance.option("formData", response.data)

	},[])

	useEffect(()=>{
		fetchUser()
	},[])


	return {userProfileFormRef}

}