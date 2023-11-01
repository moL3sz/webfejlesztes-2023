import {useUser} from "./useUser.ts";
import {RoleEnum} from "../enums/role.enum.ts";
import {useAppSelector} from "../../store/hooks.ts";


export const useIsAdminInProject = ()=>{


	const {user} = useUser();
	const currentProjectId = useAppSelector(state => state.currentProject.currentProjectId)
	const _user = {...user}
	if(typeof user?.role === "string"){
		_user.role = [user.role] as any
	}
	return !user ? false : _user.role?.find(x => x === `${currentProjectId}_${RoleEnum.ADMIN}`) !== undefined
}