import {Item, Toolbar} from "devextreme-react/toolbar";
import "./Navbar.css"
import {useAppDispatch} from "../../store/hooks.ts";
import {toggleDrawer} from "../../store/drawerSlice/drawer.slice.ts";
import {useNavigate} from "react-router-dom";
import {routes} from "../../config/routes.ts";


export const Navbar = ()=>{


	const dispatch = useAppDispatch();
	const navigate = useNavigate()
	return (
		<nav>
			<Toolbar height={"50px"} className={"navbar"} >
				<Item widget={"dxButton"} options={{icon: "menu", onClick: ()=>dispatch(toggleDrawer())}} location={"before"}/>
				<Item widget={"dxButton"} options={{icon: "globe", onClick: ()=>dispatch(toggleDrawer())}} location={"after"}/>
				<Item widget={"dxButton"} options={{icon: "bell", onClick: ()=>dispatch(toggleDrawer())}} location={"after"}/>
				<Item widget={"dxButton"} options={{icon: "login", onClick: ()=>navigate(routes.login)}} location={"after"}/>
			</Toolbar>
		</nav>

	)
}