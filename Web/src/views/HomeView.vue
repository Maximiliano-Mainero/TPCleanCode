<script setup lang="ts">
import { ref, onMounted, computed } from 'vue';

import DataTable from 'primevue/datatable';
import Column from 'primevue/column';
import Card from 'primevue/card';
let userList = ref([])
let userCount = computed(() => {
  return userList.value.length
})
const getUserList = async ()=>{
  const response = await fetch('http://localhost:5155/api/users')
  const data = await response.json()
  userList.value = data.userList
} 

onMounted( async () => {
  await getUserList()
})

</script>
<template>
<div class="grid">
  <div class="col-12">

  </div>
</div>
<div class="card">

<Card>
    <template #title> Trabajo final .Net avanzado </template>
    <template #content>
        <p class="m-0">
            La cantidad de usuarios registrados {{ userCount }}
        </p>
    </template>
</Card>
</div>
<div class="mb-3">
  <div class="grid">
    <div class="col-12">
        <DataTable :value="userList">
          <Column field="id" header="Código"></Column>
          <Column field="firstname" header="Nombre"></Column>
        </DataTable> 
    </div>
  </div>
</div>
</template>

