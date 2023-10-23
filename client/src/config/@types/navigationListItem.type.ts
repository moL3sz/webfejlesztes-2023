

export type NavigationListItemType = {
	path: string
	text: string
	role?:string
	icon?:string

}
export type NavigationListItemGroupType = {
	icon: string,
	text: string
	role?: string
	inProject?: boolean,
	items?: NavigationListItemType[]

}