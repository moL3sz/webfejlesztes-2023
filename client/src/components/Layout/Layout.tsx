import {LayoutProps} from "./@types/layout.type.ts";
import {Navbar} from "../Navbar/Navbar.tsx";
import {Drawer} from "devextreme-react/drawer";
import {NavigationList} from "../NavigationList/NavigationList.tsx";
import {useAppSelector} from "../../store/hooks.ts";


export const Layout = ({children}: LayoutProps)=>{

	const opened = useAppSelector(state => state.drawer.opened)

	return (

		<main className={"content"}>

			<Navbar/>
			<Drawer minSize={50} revealMode={"expand"} render={()=><NavigationList/>} opened={opened} openedStateMode={"shrink"}>
				<div className={"p-16"}>
					{children}
				</div>
			</Drawer>
		</main>
	)
}