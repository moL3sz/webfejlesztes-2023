import {LayoutProps} from "./@types/layout.type.ts";
import {Navbar} from "../Navbar/Navbar.tsx";
import {Drawer} from "devextreme-react/drawer";
import {NavigationList} from "../NavigationList/NavigationList.tsx";
import {useAppSelector} from "../../store/hooks.ts";
import {ScrollView} from "devextreme-react";


export const Layout = ({children}: LayoutProps)=>{

	const opened = useAppSelector(state => state.drawer.opened)

	return (

		<main className={"content"}>

			<Navbar/>
			<Drawer minSize={50} revealMode={"expand"} render={() => <NavigationList/>} opened={opened}
					openedStateMode={"shrink"}>
				<ScrollView className={"p-8 h-[80vh]"}>
					<div className={"p-8"}>
						{children}

					</div>
				</ScrollView>
			</Drawer>
		</main>
	)
}