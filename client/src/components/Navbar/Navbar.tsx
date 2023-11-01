import {Item, Toolbar} from "devextreme-react/toolbar";
import "./Navbar.css"
import {useAppDispatch} from "../../store/hooks.ts";
import {toggleDrawer} from "../../store/drawerSlice/drawer.slice.ts";
import {Button, Popover, ScrollView} from "devextreme-react";
import {useEffect, useRef, useState} from "react";
import {Link} from "react-router-dom";
import {routes} from "../../config/routes.ts";
import {useUser} from "../../core/hooks/useUser.ts";
import {useTranslation} from "react-i18next";
import {HubConnection, HubConnectionBuilder} from "@microsoft/signalr";
import {API_URL} from "../../config/globals.ts";


export const Navbar = () => {


	const dispatch = useAppDispatch();
	const popOverRef = useRef<Popover>(null)
	const {user, authenticated} = useUser();
	const {t} = useTranslation()
	const [notification, setNot] = useState<any[]>([])
	const initConnection = () => {
		if (!authenticated || !user) return;
		return new HubConnectionBuilder()
			.withUrl(API_URL + "/notification")
			.withAutomaticReconnect()
			.build();


	}
	const startConnection = async (connection: HubConnection) => {
		if (!connection) return;


		connection.on("notify", (data) => {
			const prev = JSON.parse(window.localStorage.getItem("pendingProjects") || "[]") as any[]
			const newData = [...prev, data]
			window.localStorage.setItem("pendingProjects", JSON.stringify(newData))
			console.log(newData)
			setNot(newData);

		})
		await connection.start()
		await connection.invoke("AddUser", user?.nameid);


	}
	useEffect(() => {
		const connection = initConnection()
		startConnection(connection!)
		const prev = JSON.parse(window.localStorage.getItem("pendingProjects") || "[]") as any[]
		setNot(prev)

		return () => {
			connection?.stop()
		}
	}, [user])
	return (
		<nav>
			<Toolbar height={"50px"} className={"navbar"}>
				<Item render={() => <h6>JIRA LITE</h6>} location={"center"}/>

				<Item widget={"dxButton"} options={{icon: "menu", onClick: () => dispatch(toggleDrawer())}}
					  location={"before"}/>
				<Item widget={"dxButton"} options={{icon: "globe", onClick: () => dispatch(toggleDrawer())}}
					  location={"after"}/>
				<Item render={() => {
					return <div>
						<Button icon={"bell"} id={"notify_button"}/>
						{notification.length > 0 ?
							<div
								className={"w-5 h-5 bg-red-700 flex items-center justify-center rounded-[50%] absolute top-1 "}>
								<span>{notification.length}</span>
							</div> : null}
						<Popover target={"#notify_button"} showEvent={"click"} hideEvent={"blur"} visible={notification.length > 0}>
							<ScrollView className={"max-h-20"}>
								{notification.map(x=>(<div className={"flex space-x-10 justify-between items-center"}>
									<div>Meghívtak a projektbe:</div>
									<div className={"flex items-center space-x-3"}>
										<div className={"font-bold"}>{x.title}</div>
										<Link to={routes.user.to + user?.nameid}>
											<i className="dx-icon dx-icon-eyeopen text-emerald-800 cursor-pointer hover:text-emerald-500"></i>

										</Link>
									</div>
								</div>))}
							</ScrollView>
						</Popover>

					</div>
				}} location={"after"}/>
				{
					authenticated ? <Item location={"after"} render={() => (
						<div className={"user-banner bg-lime-800 font-bold cursor-pointer"}
							 id={"user-auth-banner-panel"}>
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
						<Link to={routes.user.to + user?.nameid}
							  className={"text-white active:bg-zinc-700 p-2 rounded-lg flex items-center space-x-5"}>
							<i className={"dx-icon dx-icon-card"}></i><span>{t("caption.ownProfile")}</span>
						</Link>
						<div className="divider"></div>
						<Link to={routes.login}
							  className={"text-white active:bg-zinc-700 p-2 rounded-lg flex items-center space-x-5"}>
							<i className={"dx-icon dx-icon-to"}></i><span>{t("caption.signOut")}</span>
						</Link>

					</div>

				</Popover> : <Popover target={"#authPopover"}  showEvent={"click"} ref={popOverRef} width={250}>
					<div className={"flex flex-col space-y-4"}>
						<Link to={routes.login} className={"text-white active:bg-zinc-700 p-2 rounded-lg"}>
							{t("caption.signIn")}
						</Link>
						<Link to={routes.register}
							  className={"text-white active:bg-zinc-700 flex items-center justify-between p-2 bg-green-800 rounded-md"}>
							{t("caption.signUp")}
							<i className={"dx-icon dx-icon-add"}></i>
						</Link>
					</div>

				</Popover>
			}

		</nav>

	)
}