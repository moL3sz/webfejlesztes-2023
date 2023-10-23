import {Chart} from "devextreme-react";
import {
	ArgumentAxis,
	CommonAxisSettings,
	CommonSeriesSettings,
	Grid,
	Point,
	Series,
	Tooltip
} from "devextreme-react/chart";
import {useCallback, useEffect, useState} from "react";
import {useAppSelector} from "../../../store/hooks.ts";
import {getApi} from "../../../config/api/api.ts";
import {url} from "../../../utils/urlConstructor.ts";

export const BurnDownChart = ()=>{
	const [dataset, setDataset] = useState<any>([]);
	const currentProjectId = useAppSelector(state => state.currentProject.currentProjectId);

	const fetchDataset = useCallback(async ()=>{
		if(!currentProjectId) return;
		const response = await getApi().get(url({
			controller: "Project",
			action: "getProjectBurnDownChart",
			parameter: currentProjectId!.toString()
		}))
		setDataset(response.data);
	},[currentProjectId])
	useEffect(()=>{
			fetchDataset();
	},[currentProjectId])
	return (
		<>
			<Chart title={"Projekt burn down ábra"} dataSource={dataset}>
				<CommonSeriesSettings
					argumentField="Day"
					stepline={1}
					hoverMode={"none"}
				/>
				<Series
						valueField={"ExpectedRemainingTasksCount"}
						name={"Elvárt"}
						color={"#8d8d8d"}
						type={"area"}
				/>
				<Series
						valueField={"RemainingTasksCount"}
						argumentField={"Day"}
						name={"Valós"}
						color={"#00bdff"}
						type={"stepline"}

				>
					<Point hoverMode={"allArgumentPoints"}/>
				</Series>

				<ArgumentAxis
					argumentType={"datetime"}
					allowDecimals={true}
					valueMarginsEnabled={true}
				/>
				<Tooltip enabled={true} contentRender={(data)=>{
					const tickets = data.point.data.RemainingTasks as string[];
					return tickets.join("\n")
				}}/>
				<CommonAxisSettings>
					<Grid visible={false} />
				</CommonAxisSettings>
			</Chart>

		</>
	)
}