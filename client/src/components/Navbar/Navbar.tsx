import {Item, Toolbar} from "devextreme-react/toolbar";
import "./Navbar.css"
import {useAppDispatch} from "../../store/hooks.ts";
import {toggleDrawer} from "../../store/drawerSlice/drawer.slice.ts";
import {Button, Popover} from "devextreme-react";
import {useRef} from "react";
import {Link} from "react-router-dom";
import {routes} from "../../config/routes.ts";
import {useUser} from "../../core/hooks/useUser.ts";


export const Navbar = ()=>{


	const dispatch = useAppDispatch();
	const popOverRef = useRef<Popover>(null)
	const {user,authenticated} = useUser();
	return (
		<nav>
			<Toolbar height={"50px"} className={"navbar"} >
				<Item render={()=><h6>JIRA light</h6>} location={"center"}/>

				<Item widget={"dxButton"} options={{icon: "menu", onClick: ()=>dispatch(toggleDrawer())}} location={"before"}/>
				<Item widget={"dxButton"} options={{icon: "globe", onClick: ()=>dispatch(toggleDrawer())}} location={"after"}/>
				<Item widget={"dxButton"} options={{icon: "bell", onClick: ()=>dispatch(toggleDrawer())}} location={"after"}/>
				{
					authenticated ? <Item location={"after"} render={() => (
							<div className={"user-banner bg-lime-800 font-bold cursor-pointer"} id={"user-auth-banner-panel"}>
								<span>{user?.given_name}</span>
							</div>
						)}/> : <Item cssClass={"authModal"} render={() => {
						return (<Button icon={"login"} id={"authPopover"}/>)
					}} location={"after"}/>
				}

			</Toolbar>
			{
				authenticated ?  <Popover target={"#user-auth-banner-panel"}  showEvent={"click"} ref={popOverRef} width={250}>
					<div className={"flex flex-col"}>
						<Link to={routes.user.to +user?.nameid} className={"text-white active:bg-zinc-700 p-2 rounded-lg flex items-center space-x-5"}>
							<i className={"dx-icon dx-icon-card"}></i><span>Profile</span>
						</Link>
						<div className="divider"></div>
						<Link to={routes.login} className={"text-white active:bg-zinc-700 p-2 rounded-lg flex items-center space-x-5"}>
							<i className={"dx-icon dx-icon-to"}></i><span>Sign out</span>
						</Link>

					</div>

				</Popover> : <Popover target={"#authPopover"}  showEvent={"click"} ref={popOverRef} width={250}>
					<div className={"flex flex-col space-y-4"}>
						<Link to={routes.login} className={"text-white active:bg-zinc-700 p-2 rounded-lg"}>
							Login
						</Link>
						<Link to={routes.register} className={"text-white active:bg-zinc-700 p-2 bg-green-700 rounded-lg"}>
							Sign up
						</Link>
					</div>

				</Popover>
			}

		</nav>

	)
}