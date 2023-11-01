import {Chart} from "devextreme-react";
import {
	ArgumentAxis,
	CommonAxisSettings,
	CommonSeriesSettings,
	Grid,
	Series,
	Tooltip,
	ValueAxis
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
			<Chart  dataSource={dataset}>
				<CommonSeriesSettings argumentField="Day" type="line" />
				<Series
					valueField="ExpectedRemainingTasksCount"
					name="Elvárt fennmaradó feladatmennyiség"
					color="rgba(255, 255,255,0.3)"
					type={"splinearea"}
				/>
				<Series
					valueField="IdealRemainingTasksCount"
					name="Ideális fennmaradó feladatmennyiség"
					color="green"
				/>
				<Series
					valueField="CompletedTasksCount"
					name="Elvégzett feladatok"
					color="#ff1232"
				/>
				<ValueAxis title="Feladat mennyiség" />

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