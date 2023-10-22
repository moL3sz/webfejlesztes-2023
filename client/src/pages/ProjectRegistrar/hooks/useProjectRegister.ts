import {useCallback, useRef} from "react";
import {Form} from "devextreme-react";
import {defaultNotify} from "../../../config/dxDefault/toast.default.ts";
import {getApi} from "../../../config/api/api.ts";
import {url} from "../../../utils/urlConstructor.ts";
import {Actions} from "../../../config/api/actions.enum.ts";
import {useNavigate} from "react-router-dom";
import {routes} from "../../../config/routes.ts";
import {useTranslation} from "react-i18next";


export const useProjectRegister = () => {


	/* States */
	const navigate = useNavigate();
	const {t} = useTranslation()

	/* Refs */
	const formRef = useRef<Form>(null)

	/* Callbacks */
	const createProject = useCallback(async () => {
		const validationState = formRef.current?.instance.validate();
		if (!validationState?.isValid) {
			defaultNotify("Nem megfelelő adatokat adtál meg!", "error");
			return;
		}
		let formData = formRef.current?.instance.option("formData");
		const range = formData.Range;
		delete formData["Range"];
		formData = {...formData, Start: range[0], End: range[1]}
		try {
			const response = await getApi().post(url({
				controller: "Project",
				action: Actions.INSERT
			}), formData);

			const newProject = response.data;
			navigate(routes.dashboard);
		} catch (e) {
			defaultNotify("Valami hiba történt", "error")
		}


	}, [])

	/* Effects */


	return {
		createProject, formRef, t
	}

}