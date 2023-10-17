import {Item, Toolbar} from "devextreme-react/toolbar";
import "./Navbar.css"
import {useAppDispatch} from "../../store/hooks.ts";
import {toggleDrawer} from "../../store/drawerSlice/drawer.slice.ts";


export const Navbar = ()=>{


	const dispatch = useAppDispatch();
	return (
		<nav>
			<Toolbar height={"50px"} className={"navbar"} >
				<Item widget={"dxButton"} options={{icon: "menu", onClick: ()=>dispatch(toggleDrawer())}} location={"before"}/>
				<Item widget={"dxButton"} options={{icon: "globe", onClick: ()=>dispatch(toggleDrawer())}} location={"after"}/>
				<Item widget={"dxButton"} options={{icon: "bell", onClick: ()=>dispatch(toggleDrawer())}} location={"after"}/>
				<Item widget={"dxButton"} options={{icon: "login", onClick: ()=>dispatch(toggleDrawer())}} location={"after"}/>
			</Toolbar>
		</nav>

	)
}