export type StatusTasksType = {
	Status: {
		Id: number
		NameL1: string,
		OrderNumber: number,
	}
	Tickets: Ticket[],
}

export type Ticket = {
	Id:number,
	Title: string,
	Description?: string
	DeadLine: Date,
	ResponsibleUserId: string

}