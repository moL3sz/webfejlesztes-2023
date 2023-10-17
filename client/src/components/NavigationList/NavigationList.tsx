import {NavigationListData} from "../../config/navigation.ts";
import {TreeView} from "devextreme-react";
import {NavigationGroupItem} from "./NavigationGroupItem.tsx";
import {useAppDispatch, useAppSelector} from "../../store/hooks.ts";
import {openDrawer} from "../../store/drawerSlice/drawer.slice.ts";
import {useEffect, useRef} from "react";
import {useNavigate} from "react-router-dom";


export const NavigationList = () => {
	const dispatch = useAppDispatch();
	const opened = useAppSelector(state => state.drawer.opened);
	const treeViewRef = useRef<TreeView>(null)
	useEffect(()=>{
		if(!opened){
			console.log("asdsa")
			treeViewRef.current?.instance.collapseAll();
		}
	},[opened])
	const navigate = useNavigate();
	return (
		<TreeView dataSource={NavigationListData}
				  ref={treeViewRef}
				  width={300}
				  rtlEnabled={false}
				  onItemClick={(e)=>{
					  e.node?.expanded ? e.component.collapseItem(e.node?.key) : e.component.expandItem(e.node?.key)
					  if(!opened){
						  dispatch(openDrawer())
					  }
					  if(e.node?.children?.length == 0){
						navigate(e.node.itemData?.path)
					  }
				  }}
				  expandAllEnabled={true}
				  className={"bg-zinc-800"}
			itemRender={(data:any)=>{
				return <NavigationGroupItem {...data}/>
			}}
		/>
	)
}