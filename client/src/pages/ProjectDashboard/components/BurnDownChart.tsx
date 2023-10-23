import {Chart} from "devextreme-react";
import {ArgumentAxis, CommonAxisSettings, CommonSeriesSettings, Grid, Series, Tooltip} from "devextreme-react/chart";
import {useTicketList} from "../hooks/useTicketList.ts";

export const BurnDownChart = ()=>{

	const {tickets} = useTicketList()
	console.log(tickets)
	return (
		<>
			<Chart title={"Projekt burn down ábra"} dataSource={tickets}>

				<CommonSeriesSettings
					argumentField="StatusId"
					stepline={1}
					type={"stackedbar"}
				/>
				<Series key={"Id"}
						valueField={"Title"}
				/>
				<Tooltip
					enabled={true}
				/>
				<ArgumentAxis
					
					allowDecimals={false}
					axisDivisionFactor={1}
				/>
				<CommonAxisSettings>
					<Grid visible={true} />
				</CommonAxisSettings>
			</Chart>

		</>
	)
}