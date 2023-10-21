import {useCallback, useRef} from "react";
import {Form} from "devextreme-react";
import {useTranslation} from "react-i18next";
import {getApi} from "../../../config/api/api.ts";
import {url} from "../../../utils/urlConstructor.ts";
import {defaultNotify} from "../../../config/dxDefault/toast.default.ts";
import {useNavigate} from "react-router-dom";
import {routes} from "../../../config/routes.ts";


export const useRegister = () => {


	/* States */
	const {t} = useTranslation();
	const navigate = useNavigate();
	/* Refs */
	const formRef = useRef<Form>(null)

	/* Callbacks */

	const register = useCallback(async () => {
		const formValidationState = formRef.current?.instance.validate();
		if (!formValidationState?.isValid) return;


		const formData = formRef.current?.instance.option("formData");
		try {
			await getApi().post(url({
				controller: "Auth",
				action: "register"
			}), formData)
			defaultNotify("Sikeres regisztrálás", "success");
			navigate(routes.login)
		} catch (e) {
			defaultNotify("Hiba történt!", "error");
		}


	}, [navigate])

	/* Effects */


	return {
		register,
		formRef,
		t
	}
}