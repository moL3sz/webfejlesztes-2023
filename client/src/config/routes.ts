

export const routes = {
	projects: {
		create: "/projects/create",
		edit:  "/projects/edit/:id",
		manage: "/project/:id"
	},
	user:{
		to: "/user/profile/",
		profile:"/user/profile/:userId"
	},
	dictionaries:{
		manager: "/project/:id/data/:dictionaryName",
	},
	login: "/login",
	register: "/register",
	dashboard:"/dashboard",
}