import {Item, Toolbar} from "devextreme-react/toolbar";
import "./Navbar.css"
import {useAppDispatch} from "../../store/hooks.ts";
import {toggleDrawer} from "../../store/drawerSlice/drawer.slice.ts";
import {Button, List, Popover} from "devextreme-react";
import {useRef} from "react";
import {Item as ListItem} from "devextreme-react/list"
import {Link} from "react-router-dom";
import {routes} from "../../config/routes.ts";
import {useUser} from "../../core/auth/hooks/useUser.ts";


export const Navbar = ()=>{


	const dispatch = useAppDispatch();
	const popOverRef = useRef<Popover>(null)
	const {user,authenticated} = useUser();
	return (
		<nav>
			<Toolbar height={"50px"} className={"navbar"} >
				<Item widget={"dxButton"} options={{icon: "menu", onClick: ()=>dispatch(toggleDrawer())}} location={"before"}/>
				<Item widget={"dxButton"} options={{icon: "globe", onClick: ()=>dispatch(toggleDrawer())}} location={"after"}/>
				<Item widget={"dxButton"} options={{icon: "bell", onClick: ()=>dispatch(toggleDrawer())}} location={"after"}/>
				{
					authenticated ? <Item location={"after"} render={()=>{
						return (
							<div>MKKM</div>
						)
					}}/> : <Item cssClass={"authModal"} render={()=>{
						return (<Button icon={"login"} id={"authPopover"}/>)
					}}  location={"after"}/>
				}

			</Toolbar>
		<Popover target={"#authPopover"}  showEvent={"click"} ref={popOverRef} width={250}>
			<div className={"flex flex-col space-y-4"}>
					<Link to={routes.login} className={"text-white active:bg-zinc-700 p-2 rounded-lg"}>
						Login
					</Link>
				<Link to={routes.register} className={"text-white active:bg-zinc-700 p-2 bg-green-700 rounded-lg"}>
					Sign up
				</Link>
			</div>

		</Popover>
		</nav>

	)
}