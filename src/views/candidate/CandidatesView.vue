// ...existing code...
<template>
  <!-- Main page title and action button -->
  <div class="main-title justify-space-between d-flex">
    <div class="main-title-left">Ứng viên</div>

    <!-- Create candidate button: opens Add modal -->
    <div class="main-title-right">
      <div class="btn-create-employee d-flex align-center" @click="openModal">
        <div class="btn-left d-flex align-center">
          <div class="btn-left-icon icon icon-plus"></div>
          <div class="btn-left-title">Thêm ứng viên</div>
        </div>
        <div class="btn-right icon icon-down"></div>
      </div>
    </div>
  </div>

  <!-- Table area: search, quick actions, and table component -->
  <div class="main-table flex1">
    <div class="main-table-header d-flex justify-end align-center">
      <!-- Search input bound to `search` ref -->
      <MsInput icon="icon-search" v-model="search" placeholder="Tìm kiếm nhanh trong danh sách" />

      <!-- Quick header action icons (filter, export, quick-active, settings) -->
      <div class="d-flex justify-center align-center table-header-btn">
        <div class="icon icon-filter"></div>
      </div>
      <div class="d-flex justify-center align-center table-header-btn">
        <div class="icon icon-out"></div>
      </div>
      <div class="d-flex justify-center align-center table-header-btn">
        <div class="icon icon-quickactive"></div>
      </div>
      <div class="d-flex justify-center align-center table-header-btn">
        <div class="icon icon-settings"></div>
      </div>
    </div>

    <!-- Table component:
         - v-model paggingValue controls how many rows shown
         - :candidate-data receives paginatedCandidates
         - :table-headers is header labels
         - emits open-edit-modal with candidate index/id -->
    <ms-table v-model="paggingValue" :candidate-data="paginatedCandidates" :table-headers="tableHeaders"
      @open-edit-modal="openEditModal" />
  </div>

  <!-- Popup for Add/Edit candidate:
       - shown when isOpenModal is true
       - receives title, action, id and form data
       - emits close-modal and active-toast events -->
  <popup-candidate v-if="isOpenModal" :title="popupTitle" :candidate-id="candidateId" :action="popupAction"
    :form-cadidate="formCadidate" @close-modal=closeModal @active-toast="activeToast" />

  <!-- Toast for feedback, controlled by isActiveToast -->
  <toast-candidate v-show="isActiveToast" state-toast="success" header-toast="Thông tin" content-toast="Thông báo!" />
</template>

<script setup>
import { ref, watch } from 'vue';
import PopupCandidate from '@/views/candidate/form/MsPopupCandidate.vue';
import MsInput from '@/components/ms-input/MsInput.vue';
import MsTable from '@/components/ms-table/MsTable.vue';
import { pushDataCandidate } from '@/services/fetchCandidate.js';
import ToastCandidate from '@/components/ms-toast/MsToast.vue';

//
// Reactive state definitions
//
const tableHeaders = ref([
  // Table header labels shown in ms-table
  "Họ và tên",
  "Số điện thoại",
  "Email",
  "Chiến dịch tuyển dụng",
  "Vị trí tuyển dụng",
  "Tin Tuyển dụng",
  "Vòng tuyển dụng",
  "Đánh giá",
  "Ngày tuyển dụng",
  "Nguồn Ứng viên",
  "Trình độ đào tạo",
  "Nơi đào tạo",
  "Chuyên ngành",
  "Nơi làm việc gần đây",
  "Đơn vị sử dụng",
  "Phù Hợp với chân dung",
  "Khu vực",
  "Người giới thiệu",
  "Thông tin tiếp nhận",
  "Thuộc kho tiềm năng",
  "Tài khoản cổng ứng viên",
  "Thẻ",
  "Trạng thái",
  "Giới tính",
  "Ngày sinh",
  "Địa chỉ",
  "Lý do loại",
  "Cộng tác viên",
  "Ngày tiếp nhận",
  "Trạng thái mời nhận việc",
])

// Form model passed to popup (used for Add and Edit)
const formCadidate = ref({
  candidateName: '',
  birthday: null,
  gender: null,
  areaName: '',
  mobile: '',
  email: '',
  address: '',
  educationDegreeName: '',
  educationPlaceName: '',
  educationMajorName: '',
  applyDate: new Date(),
  channelName: '',
  collaboratorName: '',
  workPlaceRecent: '',
  jobPositionName: ''
});

// Source candidate data (mock or fetched)
const candidateData = ref(pushDataCandidate());

// UI state
const isActiveToast = ref(false);     // controls toast visibility
const popupAction = ref('Add');       // 'Add' | 'Edit'
const popupTitle = ref('Thêm mới');   // title shown in popup
const paggingValue = ref(25);         // number of rows to show in table
const candidateId = ref(-1);          // index/id of candidate being edited
const search = ref('');               // search query (not yet used for filtering)
const isOpenModal = ref(false);       // controls popup visibility

// Current paginated subset of candidateData shown in table
const paginatedCandidates = ref(candidateData.value);

// Watch for changes in paggingValue to update paginatedCandidates
watch(paggingValue, (newVal) => {
  paginatedCandidates.value = candidateData.value.slice(0, newVal);
});

//
// UI helpers and modal handlers
//

// Show a temporary toast message
const activeToast = () => {
  isActiveToast.value = true;
  setTimeout(() => {
    isActiveToast.value = false;
  }, 2000);
};

// Open Add modal and reset state accordingly
const openModal = () => {
  popupAction.value = 'Add';
  popupTitle.value = 'Thêm mới';
  isOpenModal.value = true;
};

// Open Edit modal and populate formCadidate with selected candidate data
// `id` is expected to be the index of candidate in candidateData
const openEditModal = (id) => {
  popupAction.value = 'Edit';
  popupTitle.value = 'Chỉnh sửa';
  candidateId.value = id;

  // Map candidateData fields to form model (guarding types where needed)
  formCadidate.value.candidateName = candidateData.value[id].CandidateName;
  formCadidate.value.birthday = new Date(candidateData.value[id].Birthday);
  formCadidate.value.gender = candidateData.value[id].Gender;
  formCadidate.value.areaName = candidateData.value[id].AreaName;
  formCadidate.value.mobile = candidateData.value[id].Mobile;
  formCadidate.value.email = candidateData.value[id].Email;
  formCadidate.value.address = candidateData.value[id].Address;
  formCadidate.value.educationDegreeName = candidateData.value[id].EducationDegreeName;
  formCadidate.value.educationPlaceName = candidateData.value[id].EducationPlaceName;
  formCadidate.value.educationMajorName = candidateData.value[id].EducationMajorName;
  formCadidate.value.applyDate = new Date(candidateData.value[id].ApplyDate);
  formCadidate.value.channelName = candidateData.value[id].ChannelName;
  formCadidate.value.collaboratorName = candidateData.value[id].CollaboratorName;
  formCadidate.value.workPlaceRecent = candidateData.value[id].WorkPlaceRecent;
  formCadidate.value.jobPositionName = candidateData.value[id].JobPositionName;

  isOpenModal.value = true;
}

// Close modal and reset form model; refresh candidateData from source
const closeModal = () => {
  isOpenModal.value = false;
  formCadidate.value = {
    candidateName: '',
    birthday: null,
    gender: null,
    areaName: '',
    mobile: '',
    email: '',
    address: '',
    educationDegreeName: '',
    educationPlaceName: '',
    educationMajorName: '',
    applyDate: new Date(),
    channelName: '',
    collaboratorName: '',
    workPlaceRecent: '',
    jobPositionName: ''
  };
  // Re-load candidate list (pushDataCandidate may return updated list)
  candidateData.value = pushDataCandidate();
};

</script>

<style scoped>
/* Layout and visual styles for the Candidates view */
.main-title {
  height: 30px;
}

.main-title-left {
  font-size: 20px;
  font-weight: bold;
}

.main-table {
  background-color: #ffffff;
  display: flex;
  flex-direction: column;
  margin: 24px 0;
}

/* Header that contains search and quick actions */
.main-table-header {
  /* gap: 8px; */
  padding: 16px 0;
  height: 50px;
}

.table-header-btn {
  width: 30px;
  height: 30px;
  border: 1px solid #e0e6ec;
  border-radius: 5px;
}

.main-table-header {
  gap: 10px;
  padding: 0 10px;
}

.main-table-header .icon {
  /* icon styling (color via border used as mask) */
  /* padding: 5px; */
  border: 8px solid #7a8188;
}

/* Create button styles */
.btn-create-employee {
  background-color: #0078d4;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  font-size: 14px;
}

.btn-create-employee .btn-left {
  gap: 8px;
  border-right: 0.5px solid #176cd1;
  padding: 8px 16px;
}

.btn-create-employee .btn-right {
  margin: 0 10px;
}
</style>
// ...existing code...