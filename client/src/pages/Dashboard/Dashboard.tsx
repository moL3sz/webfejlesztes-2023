import {DashboardCard} from "./components/DashboardCard/DashboardCard.tsx";
import {OwnProjects} from "./components/OwnProjects/OwnProjects.tsx";
import {memo} from "react";


export const Dashboard = memo(() => {


	return (
		<div className={"project dashboard min-w-full h-full "}>
			<h4 className={"text-center mb-2"}>Irányító pult</h4>
			<div id={"dashboard-layout"} className={"grid grid-cols-1 md:grid-cols-2 gap-5 p-5"}>
				<DashboardCard colSpan={2} title={"Projektjeim"}>
					<OwnProjects/>
				</DashboardCard>
				<DashboardCard/>
				<DashboardCard/>
				<DashboardCard/>
				<DashboardCard/>
			</div>

		</div>
	)
})