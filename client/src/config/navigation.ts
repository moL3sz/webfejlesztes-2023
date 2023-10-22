import {NavigationListItemGroupType} from "./@types/navigationListItem.type.ts";
import {routes} from "./routes.ts";


export const NavigationListData: NavigationListItemGroupType[] = [
	{
		icon: "user",
		text: "menu.user.main",
		items: [
			{
				path: "/",
				text: "menu.user.ownTickets"
			},
			{
				path: routes.dashboard,
				text: "menu.user.dashboard"
			},
			{
				path: "/",
				text: "menu.user.settings"
			}
		]
	},
	{
		icon: "toolbox",
		text: "menu.projects.main",
		items: [{
			path: routes.projects.create,
			text: "menu.projects.create"
		}, {
			path: "/",
			text: "menu.projects.own"
		}]
	},

]