import {useUser} from "./useUser.ts";
import {RoleEnum} from "../enums/role.enum.ts";
import {useAppSelector} from "../../store/hooks.ts";


export const useIsAdminInProject = ()=>{


	const {user} = useUser();
	const currentProjectId = useAppSelector(state => state.currentProject.currentProjectId)
	return !user ? false : user.role.find(x => x === `${currentProjectId}_${RoleEnum.ADMIN}`) !== undefined
}