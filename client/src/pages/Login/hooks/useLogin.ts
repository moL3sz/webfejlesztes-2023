import {useTranslation} from "react-i18next";
import {useNavigate} from "react-router-dom";
import {useCallback, useEffect, useRef} from "react";
import {Form} from "devextreme-react";
import {getApi} from "../../../config/api/api.ts";
import {url} from "../../../utils/urlConstructor.ts";
import {defaultNotify} from "../../../config/dxDefault/toast.default.ts";
import {useCookies} from "react-cookie";
import {routes} from "../../../config/routes.ts";
import jwt from "jwt-decode";


export const useLogin = ()=>{


	/* States */
	const {t} = useTranslation()
	const navigate = useNavigate()
	// eslint-disable-next-line @typescript-eslint/no-unused-vars
	const [cookies, setCookie, removeCookie] = useCookies(["AUTH_TOKEN"])

	/* Refs */
	const formRef = useRef<Form>(null)

	/* Callbacks */

	const login = useCallback(async()=>{
		const formValidationState = formRef.current?.instance.validate();
		if (!formValidationState?.isValid) return;


		const formData = formRef.current?.instance.option("formData");

		try {
			const response = await getApi().post<string>(url({
				controller: "Auth",
				action: "login"
			}), formData)

			const token = response.data;
			const jwtData = jwt(token) as any;
			const expiresDate = new Date(jwtData.exp * 1000)
			// days from now
			setCookie("AUTH_TOKEN", token, {
				path: "/",
				httpOnly: false,
				secure: true,
				expires: expiresDate
			})

			defaultNotify("Sikeres bejelentkezés", "success")
			navigate(routes.dashboard)
		}
		catch (e){
			console.log(e)
			defaultNotify("Rossz hitelesítési adatok", "error")
		}

	},[navigate])

	/* Effects */
	useEffect(()=>{
		removeCookie("AUTH_TOKEN");
	},[])



	return {
		t, formRef, login
	}

}