import {useUser} from "../../../core/hooks/useUser.ts";
import {useCallback, useMemo, useRef} from "react";
import {url} from "../../../utils/urlConstructor.ts";
import {datagridStore} from "../../../core/datagridStore.ts";
import {useTranslation} from "react-i18next";
import {getApi} from "../../../config/api/api.ts";
import {DataGrid} from "devextreme-react/data-grid";


export const usePendingProjects = () => {
	const {user} = useUser();
	const {t} = useTranslation();
	const dgRef = useRef<DataGrid>(null)
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
		const {key} = e.row;
		await getApi().put(url({
			controller: "ProjectUser",
			action: "acceptProject",
			parameter: key
		}))
		dgRef.current?.instance.refresh();

		const pendings = JSON.parse(window.localStorage.getItem("pendingProjects") || "[]") as any[];
		const newPendigs = pendings.filter(x=>x.Id === e.row.data.Id);
		window.localStorage.setItem("pendingProjects", JSON.stringify(newPendigs));
	}, [])


	return {pendingProjectStore, acceptProject,t,dgRef}
}