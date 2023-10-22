

export type NavigationListItemType = {
	path: string
	text: string
	role?:string

}
export type NavigationListItemGroupType = {
	icon: string,
	text: string
	role?: string
	items?: NavigationListItemType[]

}