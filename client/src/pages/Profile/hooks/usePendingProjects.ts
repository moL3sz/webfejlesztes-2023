import {useUser} from "../../../core/hooks/useUser.ts";
import {useCallback, useMemo} from "react";
import {url} from "../../../utils/urlConstructor.ts";
import {datagridStore} from "../../../core/datagridStore.ts";
import {useTranslation} from "react-i18next";


export const usePendingProjects = () => {
	const {user} = useUser();
	const {t} = useTranslation();
	const pendingProjectStore = useMemo(() => {

		return user ? datagridStore({
			key: "Id",
			loadUrl: url({
				controller: "ProjectUser",
				action: "getPendingProjectsByUser",
				parameter: user!.nameid
			})
		}) : [];
	}, [user])


	const acceptProject = useCallback(async (e: any) => {
		console.log(e)
	}, [])


	return {pendingProjectStore, acceptProject,t}
}