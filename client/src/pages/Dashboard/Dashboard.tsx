import {DashboardCard} from "./components/DashboardCard/DashboardCard.tsx";
import {ScrollView} from "devextreme-react";
import {OwnProjects} from "./components/OwnProjects/OwnProjects.tsx";


export  const Dashboard = ()=>{



	return (
		<div className={"project dashboard min-w-full h-full "}>
			<h4 className={"text-center mb-2"}>Irányító pult</h4>
			<ScrollView className={"h-[70vh] border-[1px] border-zinc-700 rounded-lg"}>
				<div id={"dashboard-layout"} className={"grid grid-cols-1 md:grid-cols-2 gap-5 p-5"}>
					<DashboardCard colSpan={2} title={"Projektjeim"}>
						<OwnProjects/>
					</DashboardCard>
					<DashboardCard/>
					<DashboardCard/>
					<DashboardCard/>
					<DashboardCard/>
				</div>
			</ScrollView>

		</div>
	)
}