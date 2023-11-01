import {NavigationListItemGroupType} from "./@types/navigationListItem.type.ts";
import {routes} from "./routes.ts";
import {RoleEnum} from "../core/enums/role.enum.ts";


export const NavigationListData: NavigationListItemGroupType[] = [
	{
		icon: "user",
		text: "menu.menu.main",
		items: [
			{
				icon: "home",
				path: routes.dashboard,
				text: "menu.user.dashboard"
			}]
	},
	{
		icon: "toolbox",
		text: "menu.projects.main",
		items: [{
			icon: "plus",
			path: routes.projects.create,
			text: "menu.projects.create"
		}]
	},
	{
		icon: "folder",
		text: "menu.data.main",
		inProject: true,
		role: RoleEnum.ADMIN,
		items: [{
			icon: "minus",
			path: routes.projects.manage + "/data/TicketCategory",
			text: "menu.data.TicketCategory"
		}, {
			icon: "minus",
			path: routes.projects.manage + "/data/TicketStatus",
			text: "menu.data.TicketStatus"
		}, {
			icon: "minus",
			path: routes.projects.manage + "/data/TicketPriority",
			text: "menu.data.TicketPriority"
		}]
	},

]