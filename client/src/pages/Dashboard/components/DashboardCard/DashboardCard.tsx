import "./DashboardCard.css"


type DashboardCardProps = {
	title?: string,
	colSpan?:number
	children?: any
}
export  const DashboardCard = ({colSpan,title, children}:DashboardCardProps)=>{
	console.log(colSpan)
	return (
		<div className={`${colSpan ? "col-span-" + colSpan : ""} dashboard-card rounded-lg p-4 min-h-[20em]`}>
			<h6>{title}</h6>
			{children}
		</div>
	)
}