import {useAppDispatch, useAppSelector} from "../../../store/hooks.ts";
import {useEffect, useState} from "react";
import {useCookies} from "react-cookie";
import {setUserData} from "../../../store/userSlice/user.slice.ts";
import jwt from "jwt-decode"
import {UserType} from "../../../store/@types/user.type.ts";

export const useUser = ()=>{


	const user = useAppSelector(state => state.user.user);
	const [authenticated, setAuthenticated] = useState<boolean>(true)

	const dispatch = useAppDispatch();
	const [cookies] = useCookies(["AUTH_TOKEN"])

	useEffect(()=>{
		if(cookies.AUTH_TOKEN){
			const userDecoded = jwt(cookies.AUTH_TOKEN) as UserType;
			dispatch(setUserData(userDecoded))
			setAuthenticated(true)
		}else{
			setAuthenticated(false)
		}
	},[cookies, dispatch])


	return {user, authenticated};

}