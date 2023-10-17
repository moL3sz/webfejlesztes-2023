

export type NavigationListItemType = {
	path: string
	text: string

}
export type NavigationListItemGroupType = {
	icon: string,
	text: string
	items?: NavigationListItemType[]

}