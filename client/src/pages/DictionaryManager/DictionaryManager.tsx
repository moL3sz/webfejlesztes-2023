import {useParams} from "react-router-dom";
import {useAppDispatch} from "../../store/hooks.ts";
import {useEffect} from "react";
import {setCurrentProjectId} from "../../store/currentProject/drawer.slice.ts";
import {Button, Column, DataGrid, Item, RangeRule} from "devextreme-react/data-grid";
import {datagridStore} from "../../core/datagridStore.ts";
import {dicUrl} from "../../utils/urlConstructor.ts";
import {Actions} from "../../config/api/actions.enum.ts";
import {defaultDatagridConfig} from "../../config/dxDefault/dxDatagrid.default.ts";
import {useIsAdminInProject} from "../../core/hooks/useIsAdminInProject.ts";
import {useTranslation} from "react-i18next";


export const DictionaryManager = () => {


	const {id, dictionaryName} = useParams<{ id: string, dictionaryName: string }>()

	const isAdmin = useIsAdminInProject();
	const dispatch = useAppDispatch();
	const dataSource = datagridStore({
		key: "Id",
		loadUrl: dicUrl({dictionaryName: dictionaryName!, projectId: id!, action: Actions.GET_ALL_BY_PROJECT}),
		updateUrl: dicUrl({dictionaryName: dictionaryName!, projectId: id!, action: Actions.UPDATE}),
		deleteUrl: dicUrl({dictionaryName: dictionaryName!, projectId: id!, action: Actions.DELETE}),
		insertUrl: dicUrl({dictionaryName: dictionaryName!, projectId: id!, action: Actions.INSERT})
	})
	const {t} = useTranslation()
	useEffect(() => {
		dispatch(setCurrentProjectId(id!))
	}, [])

	return (
		<div>
			<h5>{t("menu.data." + dictionaryName)}</h5>
			<DataGrid
				dataSource={dataSource}
				{...defaultDatagridConfig}
				editing={{
					mode: "form",
					allowUpdating: isAdmin,
					allowDeleting: isAdmin,
					allowAdding: isAdmin
				}}>

				<Item name="groupPanel" location="before"/>
				<Item name="searchPanel" location="after"/>
				<Item name="columnChooserButton" location="after"/>
				<Item name="addRowButton" location="after"/>
				<Item name="exportButton" location="after"/>

				<Column dataField={"NameL1"} caption={t("table.dictionaryManager.caption.NameL1")}/>
				<Column dataField={"NameL2"} caption={t("table.dictionaryManager.caption.NameL2")}/>
				<Column dataField={"OrderNumber"} defaultSortOrder={"asc"} defaultSortIndex={0}
						caption={t("table.dictionaryManager.caption.OrderNumber")}>

					<RangeRule min={2} max={9}/>
				</Column>

				<Column type={"buttons"}>
					<Button name={"edit"} visible={(data) => (!!data.row.data.ProjectId)}/>
					<Button name={"delete"} visible={(data) => (!!data.row.data.ProjectId)}/>
					<Button disabled={true} icon={"minus"} visible={(data) => (!data.row.data.ProjectId)}/>
				</Column>
			</DataGrid>
		</div>
	)
}