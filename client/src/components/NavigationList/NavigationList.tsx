import {NavigationListData} from "../../config/navigation.ts";
import {TreeView} from "devextreme-react";
import {useAppDispatch, useAppSelector} from "../../store/hooks.ts";
import {openDrawer} from "../../store/drawerSlice/drawer.slice.ts";
import {memo, useEffect, useRef} from "react";
import {useNavigate} from "react-router-dom";
import {useIsAdminInProject} from "../../core/hooks/useIsAdminInProject.ts";
import {RoleEnum} from "../../core/enums/role.enum.ts";
import {useTranslation} from "react-i18next";


export const NavigationList = memo(() => {
	const dispatch = useAppDispatch();
	const opened = useAppSelector(state => state.drawer.opened);
	const treeViewRef = useRef<TreeView>(null)
	useEffect(() => {
		if (!opened) {
			treeViewRef.current?.instance.collapseAll();
		}
	}, [opened])
	const navigate = useNavigate();
	const id = useAppSelector(state => state.currentProject.currentProjectId)
	const admin = useIsAdminInProject();
	const {t} = useTranslation();

	useEffect(() => {
		const items = NavigationListData.filter(x => {
			if (x.inProject && !id) {
				return false
			}
			return !(x.role == RoleEnum.ADMIN && !admin);

		});
		const parsed = items.map(x => ({
			...x, items: x.items?.map(y => ({
				...y, path: y.path.replace(":id", id?.toString() || "")
			}))
		}))
		treeViewRef.current?.instance.option("items", parsed)
	}, [id, admin])

	return (
		<TreeView
			ref={treeViewRef}
			width={300}
			height={"calc(100vh - 50px)"}
			displayExpr={({text})=>t(text || "")}
			onItemClick={(e) => {
				e.node?.expanded ? e.component.collapseItem(e.node?.key) : e.component.expandItem(e.node?.key)
				if (!opened) {
					dispatch(openDrawer())
				}
				if (e.node?.children?.length == 0) {
					navigate(e.node.itemData?.path)
				}
			}}
			expandAllEnabled={true}
			style={{backgroundColor: "#1b1b20"}}

		/>
	)
})