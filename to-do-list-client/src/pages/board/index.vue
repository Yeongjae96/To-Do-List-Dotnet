<template>
  <div>
    <y-data-table
      :header="header"
      :data="data"
    />
  </div>
</template>
<script>
export default {
  name: 'board-list',
  setup() {
    const header = [
      { text: '제목', width: '100px', key: 'title', align: 'center' },
      { text: '제목2', width: '300px', key: 'title2', align: 'right' },
      { text: '제목3', key: 'title3', align: 'right' },
      { text: '제목4', key: 'title4', align: 'right' },
      { text: '제목5', key: 'title5', align: 'right' },
    ]

    const data = [
      { title: '하이하이', title2: '안녕하세요 반갑습니다 저는 김 아무개입니다.', title3: 'asdf', title4: 'ㅁㅁㅁㅁ', title5: '타이틀5' },
    ]


    return {
      header,
      data
    }

  },
}
</script>
