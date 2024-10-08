import * as tagRepo from "@/db/tag-repo";
import { Spacer } from "@nextui-org/react";
import TagTable from "@/components/tag-table";

export const dynamic = 'force-dynamic'

export default async function StatsPage() {
    const tags = await tagRepo.getTags();
    tags.sort((a, b) => a.tag.localeCompare(b.tag));
    return <div>
      <Spacer></Spacer>
      <TagTable tags={tags}></TagTable>
    </div>
}