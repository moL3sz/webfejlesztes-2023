import {useMemberList} from "./hooks/useMemberList.ts";
import {UserBanner} from "../../../../components/UserBanner/UserBanner.tsx";


export const MemberList = ()=>{

	const {members} = useMemberList();

	return (
		<div className={"member-list"}>
			<div className={"flex mt-4"}>
				{members?.map((x,i)=>(
					<UserBanner FullName={x.FullName} idx={i}/>
				))}
			</div>

		</div>
	)
}