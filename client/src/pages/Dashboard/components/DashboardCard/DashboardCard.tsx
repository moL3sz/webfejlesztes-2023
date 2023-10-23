import "./DashboardCard.css"
import {memo} from "react";


type DashboardCardProps = {
	title?: string,
	colSpan?:number |string
	children?: any
}
export  const DashboardCard = memo(({colSpan,title, children}:DashboardCardProps)=>{
	return (
		<div className={`${colSpan ? "col-span-" + colSpan : ""} dashboard-card rounded-lg p-4 min-h-[20em]`}>
			<h6>{title}</h6>
			{children}
		</div>
	)
})